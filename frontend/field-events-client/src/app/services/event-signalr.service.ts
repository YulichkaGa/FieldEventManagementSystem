import * as signalR from '@microsoft/signalr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EventSignalrService {
  private hubConnection?: signalR.HubConnection;

  async startConnection(callback: (event: any) => void): Promise<void> {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5129/hubs/events')
      .withAutomaticReconnect()
      .build();

    this.hubConnection.on('EventCreated', callback);

    await this.hubConnection.start();

    console.log('✅ SignalR Connected');
  }
}
