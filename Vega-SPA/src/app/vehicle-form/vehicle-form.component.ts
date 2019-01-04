import { VehicleService } from './../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any[];
  features: any[];
  vehicle: any = {};

  constructor(
    private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes => {
      this.makes = makes;
    }, error => {
        console.log(error);
    });

    // this.vehicleService.getFeatures().subscribe(features => this.features = features);

     this.features = [ {'id': 1, 'name': 'Feature 1'} , {'id': 2, 'name': 'Feature 2'}  , {'id': 3, 'name': 'Feature 3'}];
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
  }

}
