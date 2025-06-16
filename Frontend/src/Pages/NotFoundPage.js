import React from 'react';
import { Link } from 'react-router-dom';

const NotFoundPage = () => {
  return (
    <div className="container">
      <h2>404 - Page Not Found</h2>
      <p>Sorry, the page you are looking for doesn't exist.</p>
      <Link to="/"><button>Go to Home</button></Link>
    </div>
  );
};

export default NotFoundPage;
