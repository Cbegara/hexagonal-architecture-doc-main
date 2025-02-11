# MongoDB Docker Container

This project provides a Docker container to set up a MongoDB database automatically. It includes a pre-configured `docker-compose` file to simplify the process.

---

## Prerequisites

Before you begin, ensure you have the following installed:
- **Docker**: [Install Docker](https://docs.docker.com/get-docker/)
- **Docker Compose**: [Install Docker Compose](https://docs.docker.com/compose/install/)  
  *Alternatively, you can use Docker Desktop, which includes both Docker and Docker Compose.*

---

## Steps to Run the Container

1. **Navigate to the `database` folder**:
   Open a terminal and navigate to the `database` folder where the `docker-compose.yml` file is located:
   ```bash
   cd path/to/database

2. **Start the container**:
   Run the following command to start the MongoDB container in detached mode:
   ```bash
   docker-compose up -d

3. **Verify the container is running**:
   To check if the container is running correctly, execute the following command:
   ```bash
   docker ps -a