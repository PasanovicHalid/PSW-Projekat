import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BloodBankService } from '../services/blood-bank.service';
import { News } from '../model/news.model';
import { NewsService } from '../services/news.service';
import { NewsStatus } from '../model/news-status';


@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  public dataSource = new MatTableDataSource<News>();
  public displayedColumns = ['title', 'text', 'acceptButton', 'declineButton'];
  public newses: News[] = [];
  public errorMessage: any;
  public selectedItem = new News();
  public isSelected: boolean; 

  constructor(private newsService: NewsService,private router: Router) { }

  ngOnInit(): void {
    this.newsService.getAllPending().subscribe(res =>{
      this.newses = res;
      this.dataSource.data = res;
      console.log(this.newses);
    },(error) => {this.errorMessage = error})
  }

 public  acceptNews(changedNews:News){
  //TODO:
  changedNews.status = NewsStatus.ACTIVATED;
  this.newsService.changeNewsStatus(changedNews).subscribe(res =>{
    console.log(res);
    
  },(error) => {this.errorMessage = error});

  this.newsService.getAllPending().subscribe(res =>{
    this.newses = res;
    this.dataSource.data = res;
    console.log(this.newses);
  },(error) => {this.errorMessage = error})
 }

 public declineNews(changedNews:News){
  //TODO:
  changedNews.status = NewsStatus.DECLINED;
  this.newsService.changeNewsStatus(changedNews).subscribe(res =>{console.log(res);
  
  },(error) => {this.errorMessage = error});

  this.newsService.getAllPending().subscribe(res =>{
    this.newses = res;
    this.dataSource.data = res;
    console.log(this.newses);
  },(error) => {this.errorMessage = error})
 }

}
