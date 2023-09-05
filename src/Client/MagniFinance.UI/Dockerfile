FROM node:lts-alpine AS build

WORKDIR /usr/src/app

COPY src/Client/MagniFinance.UI /usr/src/app/

RUN npm install

COPY . .

RUN npm run build

FROM nginx:1.23.2-alpine
COPY src/Client/MagniFinance.UI/nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/magni-finance.ui /usr/share/nginx/html