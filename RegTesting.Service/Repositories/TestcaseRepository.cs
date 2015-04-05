﻿using System;
using NHibernate;
using NHibernate.Criterion;
using RegTesting.Contracts.Domain;
using RegTesting.Contracts.Repositories;

namespace RegTesting.Service.Repositories
{
	/// <summary>
	/// TestsuiteRepository
	/// </summary>
	public class TestcaseRepository : BaseRepository<Testcase>, ITestcaseRepository
	{

		/// <summary>
		/// Create a TestsuiteRepository
		/// </summary>
		/// <param name="objSession">the session</param>
		public TestcaseRepository(Func<ISession> objSession)
			: base(objSession)
		{

		}


		Testcase ITestcaseRepository.GetByType(string strName)
		{
			return Session
				.CreateCriteria(typeof(Testcase))
				.Add(Restrictions.Eq("Type", strName))
				.UniqueResult<Testcase>();
		}
	}
}