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
    public class ProductoService : IProductoService
    {

        private readonly Connection _context;

        public ProductoService(Connection context)
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
                    await conexion.ExecuteAsync(ProductoCommands.DELETE, parametos, commandType: CommandType.StoredProcedure);
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

        public async Task<BaseResponse<int>> Edit(Producto usuario)
        {
            var response = new BaseResponse<int>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {

                    response.Data = await conexion.ExecuteScalarAsync<int>(ProductoCommands.EDIT, usuario, commandType: CommandType.StoredProcedure);
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

        public async Task<BaseResponse<Producto>> GetByID(int id)
        {
            var response = new BaseResponse<Producto>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {
                    var parametos = new DynamicParameters();
                    parametos.Add("Id", id);
                    response.Data = await conexion.QueryFirstAsync<Producto>(ProductoCommands.GETBYID, parametos, commandType: CommandType.StoredProcedure);
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

        public async Task<BaseResponse<IEnumerable<Producto>>> Listar()
        {
            var response = new BaseResponse<IEnumerable<Producto>>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {
                    var parametos = new DynamicParameters();

                    response.Data = await conexion.QueryAsync<Producto>(ProductoCommands.LIST, commandType: CommandType.StoredProcedure);
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

        public async Task<BaseResponse<int>> Save(Producto usuario)
        {
            var response = new BaseResponse<int>();
            try
            {
                using (var conexion = _context.ObtenerConneccion())
                {

                    response.Data = await conexion.ExecuteScalarAsync<int>(ProductoCommands.INSERT, usuario, commandType: CommandType.StoredProcedure);
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

