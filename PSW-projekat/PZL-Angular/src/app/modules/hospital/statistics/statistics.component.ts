import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Chart } from 'chart.js';
import { StatisticsService } from '../services/statistics.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  constructor(private statisticsService: StatisticsService, private router: Router) { }

  public bloodTypeChart : any;
  public genderAgeChart : any;
  public ageDoctorChart : any;
  public bloodTypeValues : any;
  public doctorNames : any;
  public doctorPercentage : any;
  public barChartLegend = "naslov";
  public barChartOptions = { }
  ngOnInit(): void {

    this.statisticsService.getStatistics().subscribe( res =>{
      //TODO retrieve data from DTO
      this.bloodTypeValues = [34,6,9,2,3,1,38,70];
      this.createBloodTypeChart();
    });


    //this.bloodTypeValues = [34,6,9,2,3,1,38,7];
    this.doctorNames = ["prvo ime","drugo ime"];
    this.doctorPercentage = [{data : [20,30], label : "doktori"}];
    
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
          data: [300,700,2000,1500,2000,1000],
          borderColor: "pink",
          label: "Female",
          fill: false,
          pointBackgroundColor: "pink"
          }
        ]
      },
    });
  }

}
