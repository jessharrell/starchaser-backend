FROM postgres
ENV POSTGRES_PASSWORD=docker
ADD ./starchaser.sql /docker-entrypoint-initdb.d/
