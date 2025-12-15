// src/app/app.component.ts
import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../Services/weather.service';
import { CommonModule } from '@angular/common'; // Might be needed for *ngFor
import { map, Observable } from 'rxjs';
import { WeatherCast } from '../Models/weather-cast';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule], // if using standalone components
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  forecasts$: Observable<WeatherCast[]> | undefined;

  constructor(private weatherService: WeatherService) {}

  ngOnInit() {
    this.forecasts$ = this.weatherService.getForecasts().pipe(map(data => {
    
      console.log('Fetched forecasts:', data);
      return data;
    }));
  }
}
