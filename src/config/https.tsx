import axios from "axios";
import React from "react";

export const axiosInstance = axios.create({});

export const AppContext = React.createContext<any>({});

axios.interceptors.request.use(config => {
	// Print this before sending any HTTP request
    document.body.classList.add('loading-indicator');
	console.log('Request was sent');
	return config;
});

axios.interceptors.response.use(config => {
	// Print this when receiving any HTTP response
    document.body.classList.remove('loading-indicator');
	console.log('Response was received');
	return config;
});