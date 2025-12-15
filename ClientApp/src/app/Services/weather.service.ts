// src/app/weather.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherCast } from '../Models/weather-cast';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  // Use a relative path during development and deployment, 
  // relying on NGINX or a proxy to route the request correctly
  private apiUrl = '/api/GetWeather'; 

  constructor(private http: HttpClient) { }

  getForecasts(): Observable<WeatherCast[]> {
    return this.http.get<WeatherCast[]>(this.apiUrl);
  }
}
