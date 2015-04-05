﻿using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace RegTesting.BuildTasks
{

	/// <summary>
	/// A Task to update the testcases
	/// </summary>
	public class UpdateTestcasesTask : Task
	{

		/// <summary>
		/// called on execution of task. Sends the new testcases to the Testservice.
		/// </summary>
		/// <returns>boolean with true in success case, else returns false</returns>
		public override bool Execute()
		{
			
			try
			{
				Log.LogMessage(MessageImportance.Normal, "Updating Testcases: START.");
				string strStage = Stage.ToLower();
				Log.LogMessage(MessageImportance.Normal, "Updating Testcases: " + strStage + ".dll -> " + EndpointAdress);
				using (WcfClient objWcfClient = new WcfClient(EndpointAdress))
				{
					objWcfClient.SendFile(File, strStage, ReleaseManager, Testsuite);
					Log.LogMessage(MessageImportance.Normal, "Updating Testcases: SUCCESS.");
					Log.LogMessage(MessageImportance.Normal, "Testresults will be sent to " + ReleaseManager );
				}
			}
			catch(Exception objException)
			{
				Log.LogErrorFromException(objException);
				return false;
			}

			return true;
		}

		/// <summary>
		/// EndpointAdress
		/// </summary>
		[Required]
		public String EndpointAdress
		{
			get;
			set;
		}

		


		/// <summary>
		/// Path to Dllfile with Testcases
		/// </summary>
		[Required]
		public String File
		{
			get;
			set;
		}

		/// <summary>
		/// Stage to update (gamma, beta, etc.)
		/// </summary>
		[Required]
		public String Stage
		{
			get;
			set;
		}

		/// <summary>
		/// ReleaseManager for tests and sending the testresults
		/// </summary>
		public String ReleaseManager
		{
			get;
			set;
		}


        /// <summary>
        /// The Testsuite to test
        /// </summary>
        public String Testsuite
        {
            get;
            set;
        }
	}
}