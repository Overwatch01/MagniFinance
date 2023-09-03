import { HttpClient, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment as env } from '../../../environments/environment';



@Injectable({
    'providedIn': 'root'
})

export class DataService {

    private baseURL: string;
    constructor(private http: HttpClient) {
      this.baseURL = env.apiUrl;
    }
  
    get(url: string) {
      return this.http.get(`${this.baseURL}${url}`);
    }
  
    getFile(url: string) {
      const options = {
        'responseType': 'arraybuffer' as 'json'
      };
  
      return this.http.get(`${this.baseURL}${url}`, options);
    }
  
    getFileWithResponse(url: string) {
      const options = {
        'observe': 'response' as const,
        'responseType': 'arraybuffer' as 'json'
      };
  
      return this.http.get(`${this.baseURL}${url}`, options);
    }
  
    post(url: string, data: any) {
      return this.http.post(`${this.baseURL}${url}`, data);
    }
  
    delete(url: string) {
      return this.http.delete(`${this.baseURL}${url}`);
    }
  
    patch(url: string, data: any) {
      return this.http.patch(`${this.baseURL}${url}`, data);
    }
  
    put(url: string, data: any) {
      return this.http.put(`${this.baseURL}${url}`, data);
    }
  
    options(url: string) {
      return this.http.options(`${this.baseURL}${url}`);
    }
  
    jsonp(url: string, callback: string) {
      return this.http.jsonp(`${this.baseURL}${url}`, callback);
    }
  
    request(req: HttpRequest<any>) {
      return this.http.request(req);
    }
  
  }