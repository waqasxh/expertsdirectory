import React from "react";

class AboutPage extends React.Component {
  render() {
    return (
      <>
        <h2>About</h2>
        <p>This app uses React as front-end with .Net Core based Web API as back-end</p>
        <p>Data is persisted to SQL Express using EF Core</p>
      </>
    );
  }
}

export default AboutPage;
