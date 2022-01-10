// Copyright (C) LEGO System A/S - All Rights Reserved
// Unauthorized copying of this file, via any medium is strictly prohibited

using LEGOMaterials;

namespace LEGOModelImporter
{
    public class Knob : CommonPart
    {
        public int connectionIndex = -1;
        public PlanarField field = null;

        public override bool IsVisible()
        {
            var connection = field.connections[connectionIndex];
            var connectedTo = connection.GetConnection() as PlanarFeature;
            if (connectedTo == null)
            {
                return true;
            }
            else
            {
                var notCovering = (connection.flags & PlanarFeature.flagsCoveringKnob) == 0 || (connectedTo.flags & PlanarFeature.flagsCoveringKnob) == 0;
                notCovering |= MouldingColour.IsAnyTransparent(part.materialIDs) || MouldingColour.IsAnyTransparent(connectedTo.field.connectivity.part.materialIDs);

                return notCovering;
            }
        }
    }
}

