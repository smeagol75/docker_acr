FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /application

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o output

WORKDIR /application/output

EXPOSE 80

# NETSKOPE CERTIFICATES ...

COPY ./certificates/nscacert.crt /usr/local/share/ca-certificates/nscacert.crt
RUN chmod 644 /usr/local/share/ca-certificates/nscacert.crt

COPY ./certificates/intcacert.cer /usr/local/share/ca-certificates/intcacert.cer
RUN chmod 644 /usr/local/share/ca-certificates/intcacert.cer

COPY ./certificates/rootcacert.cer /usr/local/share/ca-certificates/rootcacert.cer
RUN chmod 644 /usr/local/share/ca-certificates/rootcacert.cer

COPY ./certificates/nscacert.pem /usr/local/share/ca-certificates/nscacert.pem
RUN chmod 644 /usr/local/share/ca-certificates/nscacert.pem

RUN update-ca-certificates

# ... NETSKOPE CERTIFICATES

ENTRYPOINT ["dotnet", "ThisIsFine.dll"]