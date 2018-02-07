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
    public class PlayerController : BaseApiController
    {
        public PlayerController() : base(new ModelFactory(), new StatsService())
        {
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try {
                var players = StatsService.Players.Get( );
                var models = players.Select(ModelFactory.Create );

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
                var player = StatsService.Players.Get(id);
                var model = ModelFactory.Create(player);
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
            var playerEntity = ModelFactory.Create(playerModel);
            var player = StatsService.Players.Insert(playerEntity);
            var model = ModelFactory.Create(player);
            return Created(string.Format("http://localhost:50408/api/player/{0}", model.PlayerId), model);
        }

        // PUT api/<controller>/5
        [ModelValidator]
        public IHttpActionResult Put([FromBody]PlayerModel playerModel)
        {
            try
            {
                var playerEntity = ModelFactory.Create(playerModel);
                var player = StatsService.Players.Update(playerEntity);
                var model = ModelFactory.Create(player);
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
                var playerEntity = StatsService.Players.Get(id);
                
                if (playerEntity != null)
                {
                    StatsService.Players.Delete(playerEntity);
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