﻿namespace REMS.Modules.Features.Appointment;

public class BL_Appointment
{
    private readonly DA_Appointment _daAppointment;

    public BL_Appointment(DA_Appointment daAppointment)
    {
        _daAppointment = daAppointment;
    }

    public async Task<Result<AppointmentResponseModel>> CreateAppointmentAsync(AppointmentRequestModel requestModel)
    {
        var response = CheckAppointmentValue(requestModel);
        if (response is not null) return response;
        return await _daAppointment.CreateAppointmentAsync(requestModel);
    }

    public async Task<Result<object>> DeleteAppointmentAsync(int id)
    {
        var response = await _daAppointment.DeleteAppointmentAsync(id);
        return response;
    }

    public async Task<Result<AppointmentDetailList>> GetAppointmentByPropertyIdAsycn(int id, int pageNo, int pageSize)
    {
        var response = CheckPageNoandPageSize(pageNo, pageSize);
        if (response is not null) return response;
        return await _daAppointment.GetAppointmentByPropertyIdAsycn(id, pageNo, pageSize);
    }

    public async Task<Result<AppointmentResponseModel>> UpdateAppointmentAsync(int id,
        AppointmentRequestModel requestModel)
    {
        return await _daAppointment.UpdateAppointmentAsync(id, requestModel);
    }

    private Result<AppointmentResponseModel> CheckAppointmentValue(AppointmentRequestModel requestModel)
    {
        TimeSpan time;
        if (requestModel is null) return Result<AppointmentResponseModel>.Error("Model is null.");
        if (requestModel.Status is null) return Result<AppointmentResponseModel>.Error("Please Add Status.");
        if (requestModel.AppointmentTime is null)
            return Result<AppointmentResponseModel>.Error("Please Add Appointment Time.");
        if (!TimeSpan.TryParse(requestModel.AppointmentTime, out time))
            return Result<AppointmentResponseModel>.Error("Invalid Appointment Time.");
        return default;
    }

    private Result<AppointmentDetailList> CheckPageNoandPageSize(int pageNo, int pageSize)
    {
        var response = new AppointmentListResponseModel();
        if (pageNo <= 0) return Result<AppointmentDetailList>.Error("PageNo must be positive number");
        if (pageSize <= 0) return Result<AppointmentDetailList>.Error("pageSize must be positive number");
        return default;
    }


    public async Task<Result<AppointmentDetailList>> GetAppointmentByClientId(int clientId, int pageNo, int pageSize)
    {
        return await _daAppointment.GetAppointmentByClientId(clientId, pageNo, pageSize);
    }
}