# CoreInfraHQ-Blazor

CoreInfraHQ-Blazor is a Blazor application featuring user authentication and a dynamic dashboard that generates a list of transactions. This project demonstrates the integration of various technologies to create a full-stack web application, hosted on a Linux server using Nginx.

## Features

- **User Authentication**: Sign-in and sign-up functionality.
- **Dashboard**: Displays a list of transactions.
- **Data Generation**: Internal API call to generate random transaction data.
- **Hosting**: Deployed on a Linux server using Nginx.

## Live Demo
Check out the live application [here](<http://159.65.31.191:4000/login>).

## Technology Stack

- **Frontend**: Blazor
- **Backend**: .NET Core API
- **Server**: Linux
- **Web Server**: Nginx

## Getting Started

### Prerequisites

- .NET Core SDK
- Nginx (for hosting)
- Linux server

### Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/your-username/CoreInfraHQ-Blazor.git
    cd CoreInfraHQ-Blazor
    ```

2. **Install dependencies**:
    ```bash
    dotnet restore
    ```

3. **Build the project**:
    ```bash
    dotnet build
    ```

4. **Run the application locally**:
    ```bash
    dotnet run
    ```

### Deployment

1. **Publish the application**:
    ```bash
    dotnet publish -c Release
    ```

2. **Copy the publish folder to your Linux server**:
    ```bash
    scp -r ./bin/Release/net8.0/publish/ user@your-server:/var/www/CoreInfraHQ-Blazor
    ```

3. **Configure Nginx**:
    Edit the Nginx configuration file to serve the Blazor app. Here is an example configuration:
    ```nginx
    server {
        listen 80;
        server_name your-domain.com;

        location / {
            proxy_pass http://localhost:5000;
            proxy_http_version 1.1;
            proxy_set_header Upgrade $http_upgrade;
            proxy_set_header Connection keep-alive;
            proxy_set_header Host $host;
            proxy_cache_bypass $http_upgrade;
            proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
            proxy_set_header X-Forwarded-Proto $scheme;
        }
    }
    ```

4. **Restart Nginx**:
    ```bash
    sudo systemctl restart nginx
    ```

## Usage

1. **Navigate to the live application**: [Live Demo](<http://159.65.31.191:4000/login>)
2. **Click on the sign in button** to access the dashboard.
3. **View the transactions** generated by the internal API.


