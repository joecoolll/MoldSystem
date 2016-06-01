using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class StaffGroupBL
    {
        public List<StaffGroupBO> GetStaffGroup(StaffGroupBO criteria)
        {
            try
            {
                StaffGroupDA objStaffGroupDA = new StaffGroupDA();
                return objStaffGroupDA.GetStaffGroup(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertStaffGroup(StaffGroupBO newData)
        {
            try
            {
                StaffGroupDA objStaffGroupDA = new StaffGroupDA();
                objStaffGroupDA.InsertStaffGroup(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateStaffGroup(StaffGroupBO updateData)
        {
            try
            {
                StaffGroupDA objStaffGroupDA = new StaffGroupDA();
                objStaffGroupDA.UpdateStaffGroup(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteStaffGroup(StaffGroupBO deleteData)
        {
            try
            {
                StaffGroupDA objStaffGroupDA = new StaffGroupDA();
                objStaffGroupDA.DeleteStaffGroup(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
