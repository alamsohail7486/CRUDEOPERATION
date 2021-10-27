using Dapper;
using FirstProject.Interface;
using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FirstProject.Repository
{
    public class PageRepo : IPage
    {
        private readonly IDbConnection db;
        public PageRepo(IDbConnection db) //using here construtor.
        {
            this.db = db;
        }
        public Page InsertPage(Page alam)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", alam.Id);
                param.Add("@Slug", alam.Slug);
                param.Add("@title", alam.title);
                param.Add("@Description", alam.Description);
                param.Add("@Image", alam.Image);
                param.Add("@Status", alam.Status);
                var insert = SqlMapper.Query<Page>(db, "InsertPage", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
               
                return insert;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }
        public IList<Page> GetAllMyPage()
        {
            try
            {
                db.Open();

                List<Page> alam = SqlMapper.Query<Page>(db, "PageList", commandType: CommandType.StoredProcedure).ToList();
                return alam;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }
        public Page DeletePage(int id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                var delete = SqlMapper.Query<Page>(db, "DeletePage", param, commandType:CommandType.StoredProcedure).FirstOrDefault();
                return delete;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public Page UpdatePage(Page alam)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", alam.Id);
                param.Add("@Slug", alam.Slug);
                param.Add("@title", alam.title);
                param.Add("@Description", alam.Description);
                param.Add("@Image", alam.Image);
                param.Add("@status", alam.Status);
                var update = SqlMapper.Query<Page>(db, "UpdatePage", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return update;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public Page SelectPageById(int id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                var selectpage = SqlMapper.Query<Page>(db, "SelectPageById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return selectpage;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
