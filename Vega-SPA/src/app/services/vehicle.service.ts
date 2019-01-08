
import { Injectable } from '@angular/core';
// import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class VehicleService {

constructor(private http: HttpClient ) { }

getMakes() {
  return this.http.get('https://localhost:5001/api/Makes');
}

getFeatures() {
  return this.http.get('https://localhost:5001/api/features');
}

create(vehicle) {
  return this.http.post('https://localhost:5001/api/vehicles', vehicle);
}

getVehicles () {
  return this.http.get('https://localhost:5001/api/vehicles');
}

}
