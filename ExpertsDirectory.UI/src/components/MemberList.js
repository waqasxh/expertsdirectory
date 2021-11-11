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
          <th>Friends</th>
          <th>Actions</th>
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
              <td>{member.memberFriends.length}</td>

              <td>
                {(() => {
                  if (props.mode === "AddFriends") {
                    return <button className="btn btn-primary button" onClick={() => props.onAddFriend(member.id)}>
                      Add as Friend
                    </button>
                  }

                  return <Link to={"/addfriends/" + member.id}>
                    Add Friends
                  </Link>;
                })()}
              </td>
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
  ).isRequired,
  mode: PropTypes.string.isRequired,
};

export default MemberList;
