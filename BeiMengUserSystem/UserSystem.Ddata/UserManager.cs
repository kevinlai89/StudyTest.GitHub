using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace UserSystem.Data
{
	/// <summary>
	/// 数据访问类:UserManager
	/// </summary>
	public partial class UserManager
	{
		public UserManager()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "UserManager"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserManager");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(UserSystem.Model.UserManager model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserManager(");
			strSql.Append("AddTime,Pwd,Name)");
			strSql.Append(" values (");
			strSql.Append("@AddTime,@Pwd,@Name)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AddTime", DbType.String,60),
					new SQLiteParameter("@Pwd", DbType.String,60),
					new SQLiteParameter("@Name", DbType.String,60)};
			parameters[0].Value = model.AddTime;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.Name;

			object obj = DbHelperSQLite.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserSystem.Model.UserManager model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserManager set ");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("Name=@Name");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AddTime", DbType.String,60),
					new SQLiteParameter("@Pwd", DbType.String,60),
					new SQLiteParameter("@Name", DbType.String,60),
					new SQLiteParameter("@ID", DbType.Int32,8)};
			parameters[0].Value = model.AddTime;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.ID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserManager ");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserManager ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserSystem.Model.UserManager GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AddTime,Pwd,Name,ID from UserManager ");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

			UserSystem.Model.UserManager model=new UserSystem.Model.UserManager();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserSystem.Model.UserManager DataRowToModel(DataRow row)
		{
			UserSystem.Model.UserManager model=new UserSystem.Model.UserManager();
			if (row != null)
			{
				if(row["AddTime"]!=null)
				{
					model.AddTime=row["AddTime"].ToString();
				}
				if(row["Pwd"]!=null)
				{
					model.Pwd=row["Pwd"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AddTime,Pwd,Name,ID ");
			strSql.Append(" FROM UserManager ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM UserManager ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(int pageNum, int rowsNum)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM UserSystem");
            strSql.AppendFormat(" Limt{0}) offset {1}",pageNum,(pageNum-1)*rowsNum);
            return DbHelperSQLite.Query(strSql.ToString());
                


		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "UserManager";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

