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
  vehicle: any = {
    features: [],
    contact: {}
  };

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
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }

  onFeatureToogle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      const index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleService.create(this.vehicle).subscribe(response => console.log(response));
  }

}
