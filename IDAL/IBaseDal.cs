﻿
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models.Entity;
namespace IDAL
{   
	public interface IBaseDal<T> where T : class, new()
	{
		/// <summary>
		/// 基本查询方法
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		IQueryable<T> LoadEntities(Expression<Func<T, bool>> @where);
		
        /// <summary>
        /// 基本查询方法
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IQueryable<T>> LoadEntitiesAsync(Expression<Func<T, bool>> @where);

		/// <summary>
		/// 基本查询方法（不跟踪实体）
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		IQueryable<T> LoadEntitiesNoTracking(Expression<Func<T, bool>> @where);
		
        /// <summary>
        /// 基本查询方法（不跟踪实体）
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IQueryable<T>> LoadEntitiesNoTrackingAsync(Expression<Func<T, bool>> @where);

		/// <summary>
		/// 获取第一条数据
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		T GetFirstEntity(Expression<Func<T, bool>> @where);
		
        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<T> GetFirstEntityAsync(Expression<Func<T, bool>> @where);

        /// <summary>
        /// 根据ID找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);
		
        /// <summary>
        /// 根据ID找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(object id);

		/// <summary>
		/// 获取第一条数据（不跟踪实体）
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		T GetFirstEntityNoTracking(Expression<Func<T, bool>> @where);
		
        /// <summary>
        /// 获取第一条数据（不跟踪实体）
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<T> GetFirstEntityNoTrackingAsync(Expression<Func<T, bool>> @where);

		/// <summary>
		/// 判断实体是否在数据库中存在
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		bool Any(Expression<Func<T, bool>> @where);

		/// <summary>
		/// 高效分页查询方法
		/// </summary>
		/// <typeparam name="TS"></typeparam>
		/// <param name="pageIndex">第几页</param>
		/// <param name="pageSize">每页大小</param>
		/// <param name="totalCount">数据总数</param>
		/// <param name="where">where Lambda条件表达式</param>
		/// <param name="orderby">orderby Lambda条件表达式</param>
		/// <param name="isAsc">升序降序</param>
		/// <returns></returns>
		IQueryable<T> LoadPageEntities<TS>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> where, Expression<Func<T, TS>> orderby, bool isAsc = true);

		/// <summary>
		/// 高效分页查询方法（不跟踪实体）
		/// </summary>
		/// <typeparam name="TS"></typeparam>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="totalCount"></param>
		/// <param name="where"></param>
		/// <param name="orderby"></param>
		/// <param name="isAsc"></param>
		/// <returns></returns>
		IQueryable<T> LoadPageEntitiesNoTracking<TS>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> where, Expression<Func<T, TS>> orderby, bool isAsc = true);
		
        /// <summary>
        /// 根据ID删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteById(object id);

		/// <summary>
		/// 删除实体
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		bool DeleteEntity(T t);

		/// <summary>
		/// 删除多个实体并保存
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		bool DeleteEntities(IEnumerable<T> list);

		/// <summary>
		/// 更新实体
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		bool UpdateEntity(T t);

		/// <summary>
		/// 更新多个实体
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		bool UpdateEntities(IEnumerable<T> list);

		/// <summary>
		/// 添加实体
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		T AddEntity(T t);

		/// <summary>
		/// 添加多个实体并保存
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		IEnumerable<T> AddEntities(IEnumerable<T> list);

		/// <summary>
		/// 统一保存数据
		/// </summary>
		/// <returns></returns>
		int SaveChanges();

		/// <summary>
		/// 统一保存数据
		/// </summary>
		/// <returns></returns>
		Task<int> SaveChangesAsync();
	}

	
	public partial interface IFunctionDal :IBaseDal<Function>{}
	
	public partial interface IFunctionTypeDal :IBaseDal<FunctionType>{}
	
	public partial interface IPermissionDal :IBaseDal<Permission>{}
	
	public partial interface IRoleDal :IBaseDal<Role>{}
	
	public partial interface IUserGroupDal :IBaseDal<UserGroup>{}
	
	public partial interface IUserGroupPermissionDal :IBaseDal<UserGroupPermission>{}
	
	public partial interface IUserInfoDal :IBaseDal<UserInfo>{}
	
	public partial interface IUserPermissionDal :IBaseDal<UserPermission>{}
	
}