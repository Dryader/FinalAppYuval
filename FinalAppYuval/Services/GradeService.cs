using FinalAppYuval.Models;
using System.Net.Http.Json;

namespace FinalAppYuval.Services;

public class GradeService : IGradeService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<GradeService> _logger;
    private readonly IConfiguration _configuration;

    public GradeService(HttpClient httpClient, ILogger<GradeService> logger, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<StudentGrade>?> GetStudentsAndMarksAsync()
    {
        try
        {
            var apiUrl = _configuration["GradeApi:Url"];
            
            if (string.IsNullOrEmpty(apiUrl))
            {
                _logger.LogError("Grade API URL not configured in appsettings");
                return null;
            }

            _logger.LogInformation($"Fetching students from API: {apiUrl}");
            
            var response = await _httpClient.GetAsync(apiUrl);
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"API returned status code {response.StatusCode}");
                return null;
            }

            var students = await response.Content.ReadAsAsync<List<StudentGrade>>();
            _logger.LogInformation($"Successfully retrieved {students?.Count ?? 0} students");
            return students;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"HTTP request failed: {ex.Message}");
            return null;
        }
        catch (JsonException ex)
        {
            _logger.LogError($"Failed to deserialize JSON response: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected error while fetching students: {ex.Message}");
            return null;
        }
    }

    public async Task<StudentGrade?> GetStudentByIdAsync(int id)
    {
        try
        {
            var apiUrl = _configuration["GradeApi:Url"];
            
            if (string.IsNullOrEmpty(apiUrl))
            {
                _logger.LogError("Grade API URL not configured in appsettings");
                return null;
            }

            var fullUrl = $"{apiUrl}/{id}";
            _logger.LogInformation($"Fetching student from API: {fullUrl}");
            
            var response = await _httpClient.GetAsync(fullUrl);
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning($"Student with ID {id} not found. API returned status code {response.StatusCode}");
                return null;
            }

            var student = await response.Content.ReadAsAsync<StudentGrade>();
            _logger.LogInformation($"Successfully retrieved student with ID {id}");
            return student;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"HTTP request failed: {ex.Message}");
            return null;
        }
        catch (JsonException ex)
        {
            _logger.LogError($"Failed to deserialize JSON response: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected error while fetching student: {ex.Message}");
            return null;
        }
    }
}

