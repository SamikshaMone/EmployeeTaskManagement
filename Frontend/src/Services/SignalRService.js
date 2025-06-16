import * as signalR from '@microsoft/signalr';

let connection;

const startConnection = (onTaskUpdate) => {
  connection = new signalR.HubConnectionBuilder()
    .withUrl('/notificationHub')
    .withAutomaticReconnect()
    .build();

  connection.on('TaskUpdated', onTaskUpdate);

  connection.start()
    .then(() => console.log('SignalR connected'))
    .catch(err => console.error('SignalR error:', err));
};

const stopConnection = () => {
  if (connection) {
    connection.stop();
  }
};

export default {
  startConnection,
  stopConnection,
};
