﻿using Microsoft.EntityFrameworkCore;

namespace REMS.Modules.Features.Client;

public class DA_Client
{
    private readonly AppDbContext _db;

    public DA_Client(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ClientListResponseModel> GetClients()
    {
        var responseModel = new ClientListResponseModel();
        try
        {
            var clients = await _db
                .Clients
                .AsNoTracking()
                .ToListAsync();
            responseModel.DataLst = clients
                .Select(x => x.Change())
                .ToList();
            responseModel.MessageResponse = new MessageResponseModel(true, EnumStatus.Success.ToString());
        }
        catch (Exception ex)
        {
            responseModel.DataLst = new List<ClientResponseModel>();
            responseModel.MessageResponse = new MessageResponseModel(false, ex);
        }

        return responseModel;
    }

    public async Task<MessageResponseModel> CreateClientAsync(ClientRequestModel requestModel)
    {
        try
        {
            await _db.Users.AddAsync(requestModel.ChangeUser());
            int result = await _db.SaveChangesAsync();
            if (result < 0)
            {
                return new MessageResponseModel(false, "Registration Fail");
            }

            var user = await _db.Users
                .OrderByDescending(x => x.UserId)
                .AsNoTracking()
                .FirstAsync();
            requestModel.UserId = user.UserId;
            await _db.Clients.AddAsync(requestModel.Change());
            int addClient = await _db.SaveChangesAsync();
            var response = addClient > 0
                ? new MessageResponseModel(true, "Successfully Saved.")
                : new MessageResponseModel(false, "Client Registration Failed.");
            return response;
        }
        catch (Exception ex)
        {
            return new MessageResponseModel(false, ex);
        }
    }
}