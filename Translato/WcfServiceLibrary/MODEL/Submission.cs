﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: DarkSun
//helpers:

namespace WcfServiceLibrary.MODEL
{
    public class Submission
    {
        private int p_SubmissionId;
        private DateTimeOffset p_DateSubmitted;
        private bool p_IsAwarded;
        private int p_UserId;
        private int p_FileId;
        private int p_JobId;

        private Submission()
        {

        }

        public Submission(
            int SubmissionId,
            DateTimeOffset DateSubmitted,
            bool IsAwarded,
            int UserId,
            int FileId,
            int JobId)
        {
            this.SubmissionId = SubmissionId;
            this.DateSubmitted = DateSubmitted;
            this.IsAwarded = IsAwarded;
            this.UserId = UserId;
            this.FileId = FileId;
            this.JobId = JobId;
        }

        public int SubmissionId
        {
            get { return p_SubmissionId; }
            set { p_SubmissionId = value; }
        }
        public DateTimeOffset DateSubmitted
        {
            get { return p_DateSubmitted; }
            set { p_DateSubmitted = value; }
        }
        public bool IsAwarded
        {
            get { return p_IsAwarded; }
            set { p_IsAwarded = value; }
        }
        public int UserId
        {
            get { return p_UserId; }
            set { p_UserId = value; }
        }
        public int FileId
        {
            get { return p_FileId; }
            set { p_FileId = value; }
        }
        public int JobId
        {
            get { return p_JobId; }
            set { p_JobId = value; }
        }
    }

}