import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Chart } from 'chart.js';
import { DoctorStat, StatisticsDto } from '../model/statisticsdto.model';
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

  public maleAgeGroupValues : any;
  public femaleAgeGroupValues : any;
  public bloodTypeValues : any;
  public bloodTypeSymbols : any;
  public allergyValues : any;
  public allergyNames : any;
  
  public doctorNames : any;
  public doctorPercentage : any;
  public barChartLegend = "naslov";
  public barChartOptions = { }
  public stats : StatisticsDto;

  public dataSource = new MatTableDataSource<DoctorStat>();
  public displayedColumns = ['Doctor','0-18'];
  
  ngOnInit(): void {

    this.statisticsService.getStatistics().subscribe( res =>{
      let stats = Object.values(JSON.parse(JSON.stringify(res)));
      this.setFields(stats);
      
      this.createBloodTypeChart();
      this.createGenderAgeChart();
    });  
    
  }

  private setFields(stats: any[]) {
    this.maleAgeGroupValues = stats[0];
    this.femaleAgeGroupValues = stats[1];
    this.bloodTypeValues = Object.values(JSON.parse(JSON.stringify(stats[2])));
    this.bloodTypeSymbols = Object.keys(JSON.parse(JSON.stringify(stats[2])));
    let allergyValues = Object.values(JSON.parse(JSON.stringify(stats[3])));
    this.allergyNames = Object.keys(JSON.parse(JSON.stringify(stats[3])));
    this.allergyValues = [{ data: allergyValues, label: "Allergies" }];
    let doctorStats = Object.values(JSON.parse(JSON.stringify(stats[4])));
    let doctorNames = Object.keys(JSON.parse(JSON.stringify(stats[4])));
    for(let i=0;i<doctorNames.length;i++){
      let stat = new DoctorStat(doctorNames[i],(JSON.parse(JSON.stringify(doctorStats[i]))))
      this.dataSource.data.push(stat)
    }
    this.dataSource.data[0].values[1];

  }

  createBloodTypeChart(){
    this.bloodTypeChart = new Chart("bloodTypeChart", {
      type: 'bar',
      data: {
        labels: this.bloodTypeSymbols, 
	       datasets: [
          {
            data: this.bloodTypeValues,
            backgroundColor: 'red',
            label: 'Blood types'
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
          data: this.maleAgeGroupValues,
          borderColor: "lightblue",
          label: "Male",
          fill: false,
          pointBackgroundColor: "lightblue"
          }, 
          { 
          data: this.femaleAgeGroupValues,
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
