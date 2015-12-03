﻿//author: futz
//helpers:
//last_checked: futz@30.11.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.DAL;

namespace TranslatoServiceLibrary.BLL
{
    public class CtrUser
    {
        //returns 1 if successful
        //returns 0 if error
        public int insertUser(User user)
        {
            int result = -1;

            //validate userName 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.userName) ||
                !Validate.isAlphaNumericWithUnderscore(user.userName) ||
                !Validate.hasMinLength(user.userName, 5) ||
                !Validate.hasMaxLength(user.userName, 15)
               ) { result = 0; }
            //validate password(stored in the HashedPassword field at this point. Will be replaced with hash + salt later)
            if (
                result == 0 ||
                !Validate.hasMinLength(user.hashedPassword, 8) ||
                !Validate.hasMaxLength(user.hashedPassword, 100)
               ) { result = 0; }
            //validate firstName 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.firstName) ||
                !Validate.hasMinLength(user.firstName, 2) ||
                !Validate.hasMaxLength(user.firstName, 20)
               ) { result = 0; }
            //validate lastName 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.lastName) ||
                !Validate.hasMinLength(user.lastName, 2) ||
                !Validate.hasMaxLength(user.lastName, 20)
               ) { result = 0; }
            //validate Email 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.email) ||
                !Validate.hasMinLength(user.email, 5) ||
                !Validate.hasMaxLength(user.email, 50) ||
                !user.email.Contains("@")
               ) { result = 0; }
            if (result != 0)//safe to proceed
            {
                user.userName = user.userName;
                user.hashedPassword = Password.hashPassword(user.hashedPassword);
                user.firstName = user.firstName;
                user.lastName = user.lastName;
                user.email = user.email;
                user.newsletterOptOut = user.newsletterOptOut;
                user.createdOn = DateTimeOffset.Now;

                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbUsers.insertUser(user);

                        trScope.Complete();
                    } 
                }
                catch (TransactionAbortedException taEx)
                {
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        //returns
        //returns
       // public 
    }
}