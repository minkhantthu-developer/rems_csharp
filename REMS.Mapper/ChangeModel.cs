﻿using REMS.Models.Transaction;

namespace REMS.Mapper;

public static class ChangeModel
{
    #region Property Image

    public static PropertyImageModel Change(this PropertyImage dataModel)
    {
        var propertyModel = new PropertyImageModel
        {
            ImageId = dataModel.ImageId,
            PropertyId = dataModel.PropertyId,
            ImageUrl = dataModel.ImageUrl,
            Description = dataModel.Description,
            DateUploaded = dataModel.DateUploaded
        };

        return propertyModel;
    }

    #endregion

    public static Transaction Change(this TransactionRequestModel model)
    {
        return new Transaction
        {
            TransactionId = model.TransactionId,
            PropertyId = model.PropertyId,
            ClientId = model.ClientId, // Assuming BuyerId is ClientId
            TransactionDate = model.TransactionDate,
            SalePrice = model.SalePrice,
            Commission = model.Commission,
            Status = model.Status
        };
    }

    public static TransactionModel Change(this Transaction transaction)
    {
        return new TransactionModel
        {
            TransactionId = transaction.TransactionId,
            PropertyId = transaction.PropertyId,
            ClientId = transaction.ClientId, // Assuming ClientId is BuyerId
            //SellerId = transaction.Property?.OwnerId,  // Assuming OwnerId exists in Property class
            //AgentId = transaction.Property?.AgentId,  // Assuming AgentId exists in Property class
            TransactionDate = transaction.TransactionDate,
            SalePrice = transaction.SalePrice,
            Commission = transaction.Commission,
            Status = transaction.Status
        };
    }

    #region Agent

    public static User ChangeUser(this AgentRequestModel requestModel)
    {
        var user = new User
        {
            Name = requestModel.UserName!,
            Email = requestModel.Email!,
            Password = requestModel.Password!,
            Phone = requestModel.Phone,
            Role = "Agent",
            DateCreated = requestModel.DateCreate
        };
        return user;
    }

    public static Agent ChangeAgent(this AgentRequestModel requestModel)
    {
        var agent = new Agent
        {
            UserId = requestModel.UserId,
            AgencyName = requestModel.AgentName!,
            LicenseNumber = requestModel.LicenseNumber!,
            Address = requestModel.Address!
        };
        return agent;
    }

    public static AgentDto ChangeAgent(this Agent agent, User user)
    {
        return new AgentDto
        {
            AgentId = agent.AgentId,
            UserId = agent.UserId,
            AgencyName = agent.AgencyName,
            LicenseNumber = agent.LicenseNumber,
            Email = user.Email,
            PhoneNumber = user.Phone,
            Address = agent.Address
        };
    }

    #endregion

    #region Client

    public static User ChangeUser(this ClientRequestModel requestModel)
    {
        var firstName = requestModel.FirstName ?? string.Empty;
        var lastName = requestModel.LastName ?? string.Empty;
        var Name = string.Concat(firstName, !string.IsNullOrEmpty(firstName) ? " " : string.Empty, lastName);
        var user = new User
        {
            Name = Name,
            Email = requestModel.Email!,
            Password = requestModel.Password!,
            Phone = requestModel.Phone,
            Role = "Client",
            DateCreated = requestModel.DateCreate
        };
        return user;
    }

    public static Client Change(this ClientRequestModel requestModel)
    {
        var client = new Client
        {
            UserId = requestModel.UserId,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            Address = requestModel.Address
        };
        return client;
    }

    public static ClientModel Change(this Client dataModel, User user)
    {
        var clientResponseModel = new ClientModel
        {
            ClientId = dataModel.ClientId,
            UserId = dataModel.UserId,
            FirstName = dataModel.FirstName,
            LastName = dataModel.LastName,
            Address = dataModel.Address,
            Email = user?.Email,
            Phone = user?.Phone,
            Role = user?.Role
        };
        return clientResponseModel;
    }

    #endregion

    #region Property

    public static PropertyModel Change(this Property dataModel)
    {
        var propertyModel = new PropertyModel
        {
            PropertyId = dataModel.PropertyId,
            AgentId = dataModel.AgentId,
            Address = dataModel.Address,
            City = dataModel.City,
            State = dataModel.State,
            ZipCode = dataModel.ZipCode,
            PropertyType = dataModel.PropertyType,
            Price = dataModel.Price,
            Size = dataModel.Size,
            NumberOfBedrooms = dataModel.NumberOfBedrooms,
            NumberOfBathrooms = dataModel.NumberOfBathrooms,
            YearBuilt = dataModel.YearBuilt,
            Description = dataModel.Description,
            Status = dataModel.Status,
            AvailiablityType = dataModel.AvailiablityType,
            MinrentalPeriod = dataModel.MinrentalPeriod,
            Approvedby = dataModel.Approvedby,
            Adddate = dataModel.Adddate,
            Editdate = dataModel.Editdate
        };

        return propertyModel;
    }

    public static Property Change(this PropertyRequestModel requestModel)
    {
        Property property = new()
        {
            AgentId = requestModel.AgentId,
            Address = requestModel.Address,
            City = requestModel.City,
            State = requestModel.State,
            ZipCode = requestModel.ZipCode,
            PropertyType = requestModel.PropertyType,
            Price = requestModel.Price,
            Size = requestModel.Size,
            NumberOfBedrooms = requestModel.NumberOfBedrooms,
            NumberOfBathrooms = requestModel.NumberOfBathrooms,
            YearBuilt = requestModel.YearBuilt,
            Description = requestModel.Description,
            AvailiablityType = requestModel.AvailiablityType,
            MinrentalPeriod = requestModel.MinRentalPeriod
        };

        return property;
    }

    //public static PropertyResponseModel ChangeToResponseModel(this Property dataModel, List<PropertyImage> images)
    //{
    //    var propertyResponseModel = new PropertyResponseModel
    //    {
    //        Property = new PropertyModel
    //        {
    //            PropertyId = dataModel.PropertyId,
    //            Address = dataModel.Address,
    //            City = dataModel.City,
    //            State = dataModel.State,
    //            ZipCode = dataModel.ZipCode,
    //            PropertyType = dataModel.PropertyType,
    //            Price = dataModel.Price,
    //            Size = dataModel.Size,
    //            NumberOfBedrooms = dataModel.NumberOfBedrooms,
    //            NumberOfBathrooms = dataModel.NumberOfBathrooms,
    //            YearBuilt = dataModel.YearBuilt,
    //            Description = dataModel.Description,
    //            Status = dataModel.Status,
    //            DateListed = dataModel.DateListed
    //        },
    //        Images = images.Select(img => new PropertyImageModel
    //        {
    //            ImageId = img.ImageId,
    //            PropertyId = img.PropertyId,
    //            ImageUrl = img.ImageUrl,
    //            Description = img.Description,
    //            DateUploaded = img.DateUploaded
    //        }).ToList()
    //    };

    //    return propertyResponseModel;
    //}

    #endregion

    #region Review

    public static ReviewModel Change(this Review dataModel)
    {
        var reviewModel = new ReviewModel
        {
            ReviewId = dataModel.ReviewId,
            UserId = dataModel.UserId,
            PropertyId = dataModel.PropertyId,
            Rating = dataModel.Rating,
            Comments = dataModel.Comments,
            DateCreated = dataModel.DateCreated
        };

        return reviewModel;
    }

    public static Review Change(this ReviewRequestModel dataModel)
    {
        var review = new Review
        {
            UserId = dataModel.UserId,
            PropertyId = dataModel.PropertyId,
            Rating = dataModel.Rating,
            Comments = dataModel.Comments
        };

        return review;
    }

    #endregion

    #region Appointment

    public static Appointment ChangeAppointment(this AppointmentRequestModel requestModel)
    {
        var appointment = new Appointment
        {
            ClientId = requestModel.ClientId,
            PropertyId = requestModel.PropertyId,
            AppointmentDate = requestModel.AppointmentDate,
            AppointmentTime = TimeSpan.Parse(requestModel.AppointmentTime!),
            Status = requestModel.Status,
            Notes = requestModel.Notes
        };
        return appointment;
    }

    public static AppointmentModel Change(this Appointment appointment)
    {
        return new AppointmentModel
        {
            AppointmentId = appointment.AppointmentId,
            ClientId = appointment.ClientId,
            PropertyId = appointment.PropertyId,
            AppointmentDate = appointment.AppointmentDate,
            AppointmentTime = appointment.AppointmentTime.ToString(),
            Status = appointment.Status,
            Notes = appointment.Notes
        };
    }

    #endregion

    #region Transaction

    //public static Transaction Change(this TransactionRequestModel requestModel)
    //{
    //    Transaction transaction = new Transaction
    //    {

    //        PropertyId = requestModel.PropertyId,
    //        ClientId = requestModel.ClientId,
    //        //SellerId = requestModel.SellerId,
    //        //AgentId = requestModel.AgentId,
    //        TransactionDate = requestModel.TransactionDate,
    //        SalePrice = requestModel.SalePrice,
    //        Commission = requestModel.Commission,
    //        Status = requestModel.Status
    //    };
    //    return transaction;
    //}

    //public static Transaction Change(this TransactionModel requestModel)
    //{
    //    Transaction transaction = new Transaction
    //    {

    //        PropertyId = requestModel.PropertyId,
    //        ClientId = requestModel.ClientId,
    //        TransactionDate = requestModel.TransactionDate,
    //        SalePrice = requestModel.SalePrice,
    //        Commission = requestModel.Commission,
    //        Status = requestModel.Status
    //    };
    //    return transaction;
    //}

    //public static TransactionModel Change(this Transaction requestModel)
    //{
    //    TransactionModel transaction = new TransactionModel
    //    {

    //        PropertyId = requestModel.PropertyId,
    //        BuyerId = requestModel.BuyerId,
    //        SellerId = requestModel.SellerId,
    //        AgentId = requestModel.AgentId,
    //        TransactionDate = requestModel.TransactionDate,
    //        SalePrice = requestModel.SalePrice,
    //        Commission = requestModel.Commission,
    //        Status = requestModel.Status
    //    };
    //    return transaction;
    //}

    #endregion
}