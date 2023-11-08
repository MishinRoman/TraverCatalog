FROM node:18-alpine as builder
WORKDIR /
COPY package.json app/package.json
RUN apk --no-cache add --virtual builds-deps build-base python
RUN npm install
COPY . /app
RUN npm run build
FROM node:18-alpine
WORKDIR /
COPY --from=builder /app/dist /app
COPY package.json /app/package.json
RUN apk --no-cache add --virtual builds-deps build-base python
RUN npm install --only=prod
EXPOSE 8080 
USER node
CMD ["node", "index.js"]