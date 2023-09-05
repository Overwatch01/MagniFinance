# FROM node:lts-alpine
# # ENV NODE_ENV=production
# WORKDIR /usr/src/app
# COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
# RUN npm ci
# COPY . .
# EXPOSE 4200
# RUN chown -R node /usr/src/app
# USER node
# CMD ["npm", "start"]



# Stage 1: Compile and Build angular codebase

# Use official node image as the base image
FROM node:latest as build

# Set the working directory
WORKDIR /usr/local/app

# Add the source code to app
COPY src/Client/MagniFinance.UI /usr/local/app/

# COPY ["package*.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]


# Install all the dependencies
RUN npm install

# Generate the build of the application
RUN npm run build


# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest

# Copy the build output to replace the default nginx contents.
COPY --from=build /usr/local/app/dist/magni-finance.ui /usr/share/nginx/html

# Expose port 80
EXPOSE 80