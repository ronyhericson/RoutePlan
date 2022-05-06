using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using RoutePlan.Domain.Entities;
using RoutePlan.Domain.Interfaces;

namespace RoutePlan.Infrastructure.Repositories
{
    public class RoutePlanRepository : IRoutePlanRepository
    {
        private readonly IConnectionManager _connectionManager;
        public RoutePlanRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        
        public async Task<IEnumerable<RoutePlanEntity>> Get(int id = 0)
        {
            var result = new List<RoutePlanEntity>();

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = string.Format("Select * from routeplan {0} order by id ", id > 0 ? " Where id = " + id.ToString() : string.Empty);
                   
                    result =(List<RoutePlanEntity>)await connection.QueryAsync<RoutePlanEntity>(query);;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return result;
                }

            }

            return result;
        }

        public async Task<int> Create(RoutePlanEntity routePlan)
        {
            int result = 0;

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = "INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), @Origin, @Destiny, @Price) RETURNING ID;";
                    var FluxoCaixaQuery = await connection.QueryFirstOrDefaultAsync<RoutePlanEntity>(query, new
                    {                      
                        Origin = routePlan.origin,
                        Destiny = routePlan.destiny,
                        Price = routePlan.price                        
                    });

                    result = 1;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    result = 0;
                }

            }

            return result;
        }

        public async Task<int> Update(RoutePlanEntity routePlan)
        {
            int result = 0;

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = "UPDATE routeplan SET origin = @Origin, destiny = @Destiny, price = @Price WHERE id = @CodRoute";
                    var FluxoCaixaQuery = await connection.QueryFirstOrDefaultAsync<RoutePlanEntity>(query, new
                    {                      
                        Origin = routePlan.origin,
                        Destiny = routePlan.destiny,
                        Price = routePlan.price,
                        CodRoute = routePlan.id                        
                    });

                    result = 1;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    result = 0;
                }

            }

            return result;
        }

        public async Task<long> Remove(int id)
        {
            long result = 0;
            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var deleteItem = @"delete from routeplan where id = @CodRoute";
                    var deleteItemQuery = await connection.QueryFirstOrDefaultAsync<RoutePlanEntity>(deleteItem, new
                    {
                        CodRoute = id
                    });

                    result = 1;
                }
                catch (Exception ex)
                {
                    var error = ex.Message; 
                }
            }

            return result;
        }
    }
}