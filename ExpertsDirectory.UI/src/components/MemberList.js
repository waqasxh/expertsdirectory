import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

function MemberList(props) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Email</th>
          <th>Website</th>
        </tr>
      </thead>
      <tbody>
        {props.members.map(member => {
          return (
            <tr key={member.id}>
              <td>
                <Link to={"/member/" + member.id}>{member.name}</Link>
              </td>
              <td>{member.email}</td>
              <td>{member.website}</td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

MemberList.propTypes = {
  members: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string.isRequired,
      email: PropTypes.string.isRequired,
      website: PropTypes.string.isRequired
    })
  ).isRequired
};

export default MemberList;
