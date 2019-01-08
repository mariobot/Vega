import { VehicleService } from './../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { load } from '@angular/core/src/render3';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  list: any = [];

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.loadVehicles();
  }

  loadVehicles() {
    this.vehicleService.getVehicles().subscribe(response => {
      this.list = response;
      console.log(this.list);
    });
  }

}
