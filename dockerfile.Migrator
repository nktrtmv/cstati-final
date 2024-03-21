# Use the latest Golang base image
FROM golang:latest

# Install necessary packages
RUN apt-get update && \
    apt-get install -y curl ca-certificates && \
    rm -rf /var/lib/apt/lists/*

# Set the Dockerize version
ENV DOCKERIZE_VERSION v0.7.0

# Download and install Dockerize
RUN curl -L https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz | tar xz -C /usr/local/bin

# Install Goose database migrator
RUN go install github.com/pressly/goose/cmd/goose@latest

# Set the working directory
WORKDIR /migrations