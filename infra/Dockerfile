
# Use an official Python runtime as a parent image
FROM mcr.microsoft.com/dotnet/core/aspnet

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . /app

# Make port 8888 available to the world outside this container
EXPOSE 8888

# Define environment variable
ENV NAME api

# Run app.py when the container launches
CMD ["dotnet", "webapi.dll"]
