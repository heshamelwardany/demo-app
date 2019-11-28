FROM microsoft/mssql-server-linux:2017-latest
ENV SA_PASSWORD=Pass@word
ENV ACCEPT_EULA=Y

COPY ["database/entrypoint.sh", "entrypoint.sh"]
COPY ["database/SqlCmdStartup.sh", "SqlCmdStartup.sh"]
COPY ["database/SqlCmdScript.Sql", "SqlCmdScript.sql"]

RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh