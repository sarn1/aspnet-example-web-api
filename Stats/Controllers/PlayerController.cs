using Stats.DataAccess;
using Stats.Filters;
using Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stats.Controllers
{
    public class PlayerController : ApiController
    {
        private readonly IStatsService _service;
        private readonly IModelFactory _modelFactory;

        public PlayerController()
        {
            _service = new StatsService();
            _modelFactory = new ModelFactory();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try {
                var players = _service.Players.Get( );
                var models = players.Select( _modelFactory.Create );

                return Ok( models );
            } catch ( Exception ex ) {
                return InternalServerError( ex );
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var player = _service.Players.Get(id);
                var model = _modelFactory.Create(player);
                return Ok(model);
            } catch(Exception ex)
            {
                // Some Logging Functionality

                // if debug
                return InternalServerError( ex );
                // else
                //return InternalServerError(ex);
            }
        }


        // POST api/<controller> 
        [ModelValidator]
        public IHttpActionResult Post([FromBody]PlayerModel playerModel)
        {
            var playerEntity = _modelFactory.Create(playerModel);
            var player = _service.Players.Insert(playerEntity);
            var model = _modelFactory.Create(player);
            return Created(string.Format("http://localhost:50408//api/player/{0}", model.PlayerId), model);
        }

        // PUT api/<controller>/5
        [ModelValidator]
        public IHttpActionResult Put([FromBody]PlayerModel playerModel)
        {
            try
            {
                var playerEntity = _modelFactory.Create(playerModel);
                var player = _service.Players.Update(playerEntity);
                var model = _modelFactory.Create(player);
                return Ok(model);
            } catch(Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var playerEntity = _service.Players.Get(id);
                
                if (playerEntity != null)
                {
                    _service.Players.Delete(playerEntity);
                } else
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}