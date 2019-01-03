import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FeatureService {

constructor(private http: HttpClient) { }

  getFeatures() {
    return this.http.get('https://localhost:5001/api/features');
  }

}
