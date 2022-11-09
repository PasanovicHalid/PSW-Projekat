import { Component, OnInit } from '@angular/core';
import { Chart, Title } from 'chart.js';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  constructor() { }

  public bloodTypeChart : any;
  public genderAgeChart: any;
  public bloodTypeValues : any;

  ngOnInit(): void {
    this.bloodTypeValues = [34,5,9,4,2,1,38,7];
    this.createBloodTypeChart();
    this.createGenderAgeChart();
  }

  createBloodTypeChart(){
    this.bloodTypeChart = new Chart("bloodTypeChart", {
      type: 'pie',
      data: {
        labels: ['A+', 'A-', 'B+','B-','AB+','AB-','O+','O-'], 
	       datasets: [
          {
            data: this.bloodTypeValues,
            backgroundColor: ['red','green','blue','yellow','orange','purple','gray','teal']
          } 
        ]
      },
      options: {
        aspectRatio:2.5       
      }
    });
  }

  createGenderAgeChart(){
    this.genderAgeChart = new Chart("genderAgeChart", {
      type: "line",
      data: {
        labels: ['0-18','18-30','30-45','45-60','60-80','80+'],
        datasets: [
          { 
          data: [860,1140,1060,1060,1070,1110],
          borderColor: "lightblue",
          label: "Male",
          fill: false,
          pointBackgroundColor: "lightblue"
          }, 
          { 
          data: [300,700,2000,5000,6000,4000],
          borderColor: "pink",
          label: "Female",
          fill: false,
          pointBackgroundColor: "pink"
          }
        ]
      },
      options: {
        
      }
    });
  }

}
