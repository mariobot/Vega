
import { Injectable } from '@angular/core';
// import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class MakeService {

constructor(private http: HttpClient ) { }

getMakes() {
  return this.http.get('https://localhost:5001/api/Makes');
}

}
