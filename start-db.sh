#!/bin/bash

DOCKER_IMAGE=`docker images -a | grep starchaser`

if [ -z "$DOCKER_IMAGE" ]
then
    echo "CREATING DOCKER IMAGE..."
    docker build -t starchaser-db-image .
else
    echo "DOCKER IMAGE EXISTS"
fi

DOCKER_CONTAINER=`docker container ls | grep starchaser`

if [ -z "$DOCKER_CONTAINER" ]
then 
    echo "INITIALIZING DOCKER CONTAINER..."
    docker run -d --name starchaser-db -p 5432:5432 starchaser-db-image &>/dev/null
    if [ $? ]
    then 
        docker start starchaser-db
    fi
    echo "starchaser-db IS RUNNING."
else
    echo "starchaser-db ALREADY RUNNING"
fi

