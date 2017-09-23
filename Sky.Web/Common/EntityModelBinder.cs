﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewLife.Log;
using NewLife.Reflection;
using XCode;

namespace Sky.Web.Common
{
    /// <inheritdoc />
    /// <summary>实体模型绑定器。特殊处理XCode实体类</summary>
    public class EntityModelBinder : DefaultModelBinder
    {
        /// <summary>创建模型。对于有Key的请求，使用FindByKeyForEdit方法先查出来数据，而不是直接反射实例化实体对象</summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        protected override Object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.As<IEntity>())
            {
                var fact = EntityFactory.CreateOperate(modelType);
                if (fact != null)
                {
                    var rvs = controllerContext.RouteData.Values;
                    var uk = fact.Unique;
                    if (uk != null && rvs[uk.Name] != null)
                    {
                        // 查询实体对象用于编辑
                        var entity = GetEntity(fact.EntityType, rvs[uk.Name]) ?? fact.FindByKeyForEdit(rvs[uk.Name]) ?? fact.Create();

                        var fs = controllerContext.HttpContext.Request.Form;
                        // 提前填充动态字段的扩展属性
                        foreach (var item in fact.Fields)
                        {
                            if (item.IsDynamic && fs.AllKeys.Contains(item.Name)) entity.SetItem(item.Name, fs[item.Name]);
                        }

                        return entity;
                    }

                    return fact.Create();
                }
            }

            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

        private static String GetCacheKey(Type type, Object key)
        {
            return "CubeModel_{0}_{1}".F(type.FullName, key);
        }

        /// <summary>呈现表单前，保存实体对象。提交时优先使用该对象而不是去数据库查找，避免脏写</summary>
        /// <param name="entity"></param>
        internal static void SetEntity(IEntity entity)
        {
            var ctx = HttpContext.Current;
            var fact = EntityFactory.CreateOperate(entity.GetType());
            var uk = fact.Unique;
            var ckey = GetCacheKey(entity.GetType(), entity[uk.Name]);
            ctx.Session[ckey] = entity;
        }

        private static IEntity GetEntity(Type type, Object key)
        {
            var ctx = HttpContext.Current;
            var ckey = GetCacheKey(type, key);
            return ctx.Session[ckey] as IEntity;
        }
    }

    /// <summary>实体模型绑定器提供者，为所有XCode实体类提供实体模型绑定器</summary>
    public class EntityModelBinderProvider : IModelBinderProvider
    {
        /// <summary>获取绑定器</summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType.As<IEntity>()) return new EntityModelBinder();

            return null;
        }

        static EntityModelBinderProvider()
        {
            XTrace.WriteLine("注册实体模型绑定器：{0}", typeof(EntityModelBinderProvider).FullName);
            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider());
        }

        /// <summary>注册到全局模型绑定器提供者集合</summary>
        public static void Register()
        {
            // 引发静态构造，只执行一次
        }
    }
}