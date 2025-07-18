﻿namespace StudentsInventory.Models
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public Response(bool success, string message, T? data = default, List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public Response(bool success, string message, List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }
    }
}