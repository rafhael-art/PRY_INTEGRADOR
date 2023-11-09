using System;
using Dapper;
using PRY.Common;
using System.Data;
using PRY.DataAcces.Bases;
using PRY.DataAcces.Interfaces;
using PRY.Domain.Context;
using PRY.Domain.Entidades;
using PRY.Common.Commands;

namespace PRY.DataAcces.Servicios
{
    public class MesaService : IMesaService
    {
        private readonly Connection _context;

        public MesaService(Connection context)
        {
            _context = context;
        }

        public async Task<BaseResponse<bool>> Delete(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {
                    var parametos = new DynamicParameters();
                    parametos.Add("Id", id);
                    await conexion.ExecuteAsync(MesaCommands.DELETE, parametos, commandType: CommandType.StoredProcedure);
                    response.IsSucces = true;
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSucces = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<int>> Edit(Mesa usuario)
        {
            var response = new BaseResponse<int>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {

                    response.Data = await conexion.ExecuteScalarAsync<int>(MesaCommands.EDIT, usuario, commandType: CommandType.StoredProcedure);
                    response.IsSucces = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSucces = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<Mesa>> GetByID(int id)
        {
            var response = new BaseResponse<Mesa>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {
                    var parametos = new DynamicParameters();
                    parametos.Add("Id", id);
                    response.Data = await conexion.QueryFirstAsync<Mesa>(MesaCommands.GETBYID, parametos, commandType: CommandType.StoredProcedure);
                    response.IsSucces = true;

                }
            }
            catch (Exception ex)
            {

                response.IsSucces = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Mesa>>> Listar()
        {
            var response = new BaseResponse<IEnumerable<Mesa>>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {
                    var parametos = new DynamicParameters();

                    response.Data = await conexion.QueryAsync<Mesa>(MesaCommands.LIST, commandType: CommandType.StoredProcedure);
                    response.IsSucces = true;

                }
            }
            catch (Exception ex)
            {

                response.IsSucces = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<int>> Save(Mesa usuario)
        {
            var response = new BaseResponse<int>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {

                    response.Data = await conexion.ExecuteScalarAsync<int>(MesaCommands.INSERT, usuario, commandType: CommandType.StoredProcedure);
                    response.IsSucces = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSucces = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

