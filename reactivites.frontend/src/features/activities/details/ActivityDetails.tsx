import { Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useParams } from "react-router-dom";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import ActivityDetailedHeader from "./ActivityDetailedHeader";
import ActivityDetailedInfo from "./ActivityDetailInfo";
import ActivityDetailedChat from "./ActivityDetailChat";
import ActivityDetailedSidebar from "./ActivityDetailedSidebar";

export default observer(function AcitivityDetails()
{
  const { activityStore} = useStore();
  const {selectedActivity: activity, loadActivity, loadingInitial } = activityStore;
  let { id } = useParams();

  useEffect(() => {
    if(id) loadActivity(id)
  }, [id, loadActivity])
  if(loadingInitial || !activity) return <LoadingComponent />;
    return (
        <Grid>
          <Grid.Column width={10}>
            <ActivityDetailedHeader activity={activity}/>
            <ActivityDetailedInfo activity={activity}/>
            <ActivityDetailedChat />
          </Grid.Column>
          <Grid.Column width={6}>
          <ActivityDetailedSidebar />
          </Grid.Column>
        </Grid>
    )
    
})