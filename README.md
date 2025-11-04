# FCG_MVP - Fase 1 (Entregáveis)

Este documento descreve como executar e validar o projeto fornecido e reúne os entregáveis exigidos pela Fase 1.

## Conteúdo deste pacote
- Código fonte (mantido conforme enviado no pacote original).
- Documentos de entrega, roteiro de vídeo, e instruções de execução e validação (nesta pasta `docs/`).

## Como preparar o ambiente (resumo)
1. Abra a solução no Visual Studio ou VS Code.
2. Verifique o `appsettings.json` para a connection string (já configurada conforme instruções do grupo).
3. Instale ferramentas se necessário:
   - .NET 8 SDK
   - `dotnet-ef` (se for usar migrations localmente): `dotnet tool install --global dotnet-ef`
4. No diretório do projeto principal execute:
   - `dotnet restore`
   - `dotnet ef database update`
   - `dotnet run` (ou rode via Visual Studio)

> Se sua connection string aponta para um servidor SQL (ex.: `Server=NB-WANDERLEIDIA,1433;...`), garanta conectividade e credenciais.

## Principais endpoints (reconstruídos)
- `POST /api/auth/register` — cadastro de usuário: `{ name, email, password }`
- `POST /api/auth/login` — login: `{ email, password }` -> retorna JWT
- `GET /api/games` — lista pública de jogos
- `GET /api/games/{id}` — detalhes do jogo
- `POST /api/games` — criar jogo (Admin)
- `DELETE /api/games/{id}` — deletar jogo (Admin)
- `GET /api/games/library` — biblioteca do usuário (autenticado)

## Notas rápidas de conformidade
- Autenticação JWT: verifique `Jwt` config em `appsettings.json`.
- Roles: verifique uso de claims de role em controllers (ex.: `[Authorize(Roles = "Admin")]`).
- Password hashing: verifique uso de BCrypt no serviço de senha.
- Swagger: abra `/swagger` em ambiente de desenvolvimento.
