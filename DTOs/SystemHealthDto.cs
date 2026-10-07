namespace Tars.DTOs;

public record SystemHealthDto(
    string Status,
    string AppName,
    string Environment,
    DateTime ServerTimeUtc,
    string Version
);