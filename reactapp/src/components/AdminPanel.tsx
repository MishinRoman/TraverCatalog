import React from "react";
import AddingForm from "./AddingForm";

type Props = {};

const AdminPanel = (props: Props) => {
  return (
    <div className="container  w-90 m-auto p-4">
      <AddingForm />
    </div>
  );
};

export default AdminPanel;
