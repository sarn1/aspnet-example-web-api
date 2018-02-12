using Stats.DataAccess;
using Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Stats.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        // rather than have these 2 properties in both PlayerController and TeamController, we put them here and have those controller inherit this.
        private readonly IStatsService _service;
        private IModelFactory _modelFactory;

        protected BaseApiController( IStatsService statsService)
        {
            _service = statsService;
        }

        protected IModelFactory ModelFactory
        {
            get {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request);
                }

                    return _modelFactory;
            }
        }

        protected IStatsService StatsService
        {
            get { return _service; }
        }
    }
}